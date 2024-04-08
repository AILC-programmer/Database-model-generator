using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DatabaseModelGenerator
{
    public partial class MainForm : Form
    {
        private SqlConnectionStringBuilder stringBuilder;

        public MainForm()
        {
            InitializeComponent();
            UserIDCheckBox.Checked = false;
        }

        private async void DBConnectionButton_Click(object sender, EventArgs e)
        {
            this.stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = DataSourceTextBox.Text;
            stringBuilder.InitialCatalog = "Master";
            stringBuilder.IntegratedSecurity = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM sys.databases";
                        var reader = await command.ExecuteReaderAsync();
                        DatabasesComboBox.Items.Clear();
                        while (reader.Read())
                        {
                            DatabasesComboBox.Items.Add(reader["name"]);
                        }
                        DatabasesComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error");
            }
        }

        private async void DatabasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateButton.Enabled = true;
            stringBuilder.InitialCatalog = DatabasesComboBox.SelectedItem.ToString();
            SelectAllCheckBox.Visible = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "Select * from INFORMATION_SCHEMA.TABLES";
                        ItemsPanel.Visible = false;
                        TablesReaderProgressBar.Visible = true;

                        var reader = await command.ExecuteReaderAsync();
                        command.StatementCompleted += Command_StatementCompleted;
                        TablesCheckedListBox.Items.Clear();
                        string item;
                        while (reader.Read())
                        {
                            item = reader["TABLE_SCHEMA"].ToString();
                            item += $".{reader["TABLE_NAME"]}";
                            TablesCheckedListBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error");
            }
        }

        private void Command_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            SetItemsEnabled(true);
            ItemsPanel.Visible = true;
            TablesReaderProgressBar.Visible = false;
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < TablesCheckedListBox.Items.Count; i++)
            {
                TablesCheckedListBox.SetItemChecked(i, SelectAllCheckBox.Checked);
            }
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowNewFolderButton = true;

            if (browser.ShowDialog() != DialogResult.OK) return;

            var selectedItems = TablesCheckedListBox.CheckedItems;
            var rootDir = browser.SelectedPath;

            string entitiesDir = Path.Combine(rootDir, "Entities");
            string interfaceDir = Path.Combine(rootDir, "Abstracts");
            string repositoryDir = Path.Combine(rootDir, "Repositories");

            if (!Directory.Exists(entitiesDir))
                Directory.CreateDirectory(entitiesDir);
            if (!Directory.Exists(interfaceDir))
                Directory.CreateDirectory(interfaceDir);
            if (!Directory.Exists(repositoryDir))
                Directory.CreateDirectory(repositoryDir);

            SetItemsEnabled(false);
            ItemsPanel.Enabled = false;
            ModelGeneratingProgressBar.Visible = true;

            try
            {
                string schema;
                string tableName;
                foreach (var item in selectedItems)
                {
                    schema = item.ToString().Split('.')[0];
                    tableName = item.ToString().Split('.')[1];
                    var columnModels = await Tools.getTableColumns(schema, tableName, stringBuilder.ConnectionString);
                    generateEntity(schema, tableName, entitiesDir, columnModels);
                    generateInterface(tableName, interfaceDir, columnModels);
                    generateRepository(schema, tableName, repositoryDir, columnModels);
                }
                MessageBox.Show("All files generated successfuly.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Model generate error");
            }
            finally
            {
                SetItemsEnabled(true);
                ItemsPanel.Enabled = true;
                ModelGeneratingProgressBar.Visible = false;
            }
        }

        private void generateEntity(string schema, string tableName, string path, List<ColumnModel> columnModels)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine($"using {RootNamespaceTextBox.Text}.{SecondryNamespaceTextBox.Text};");
            builder.AppendLine();
            builder.AppendLine($"namespace {RootNamespaceTextBox.Text}.Entities");
            builder.AppendLine("{");
            builder.AppendLine($"    [{TableTextBox.Text}(\"{schema}\",\"{tableName}\")]");
            builder.AppendLine($"    public class {getSingularNoun(tableName)}");
            builder.AppendLine("    {");
            foreach (var columnModel in columnModels)
            {
                if (!string.IsNullOrEmpty(PrimaryKeyTextBox.Text) && columnModel.IsPrimary)
                    builder.AppendLine($"        [{PrimaryKeyTextBox.Text}]");
                
                if (!string.IsNullOrEmpty(UniqueAttributeTextBox.Text) && columnModel.IsUnique)
                    builder.AppendLine($"        [{UniqueAttributeTextBox.Text}]");

                if (!string.IsNullOrEmpty(ComputedColumnTextBox.Text) && columnModel.IsComputed)
                    builder.AppendLine($"        [{ComputedColumnTextBox.Text}]");

                if (!string.IsNullOrEmpty(IdentityColumnTextBox.Text) && columnModel.IsIdentity)
                    builder.AppendLine($"        [{IdentityColumnTextBox.Text}]");

                if (!string.IsNullOrEmpty(AllowNullTextBox.Text) && columnModel.IsNullable)
                    builder.AppendLine($"        [{AllowNullTextBox.Text}]");

                if (!string.IsNullOrEmpty(MaxLengthTextBox.Text) && columnModel.MaxLength != 0)
                    builder.AppendLine($"        [{MaxLengthTextBox.Text}({columnModel.MaxLength})]");

                builder.AppendLine($"        public {Tools.ConvertSqlToClr(columnModel.DataType, columnModel.IsNullable)} {columnModel.Name} " + "{ get; set; }");
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            File.WriteAllText(Path.Combine(path, getSingularNoun(tableName) + ".cs"), builder.ToString());
        }

        private void generateInterface(string tableName, string path, List<ColumnModel> columnModels)
        {
            string repoName = $"I{tableName}Repository";

            List<string> classLines = new List<string>();

            classLines.Add("using System;");
            classLines.Add($"using {RootNamespaceTextBox.Text}.{SecondryNamespaceTextBox.Text};");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("using System.Data.SqlClient;");
            classLines.Add("using System.Threading.Tasks;");
            classLines.Add($"using {RootNamespaceTextBox.Text}.Entities;");
            classLines.Add("");
            classLines.Add($"namespace  {RootNamespaceTextBox.Text}.RepositoryAbstracts");
            classLines.Add("{");

            classLines.Add($"    public interface {repoName} : {RepositoryInterfaceTextBox.Text}<{getSingularNoun(tableName)}>");
            classLines.Add("    {");

            foreach (var column in columnModels)
            {
                classLines.Add($"        Task<List<{getSingularNoun(tableName)}>> GetBy{column.Name}Async ({Tools.ConvertSqlToClr(column.DataType, column.IsNullable)} value);");
            }

            classLines.Add("    }");
            classLines.Add("}");

            File.WriteAllLines(Path.Combine(path, repoName + ".cs"), classLines);
        }

        private void generateRepository(string schema, string tableName, string path, List<ColumnModel> columnModels)
        {
            List<string> classLines = new List<string>();

            classLines.Add("using System;");
            classLines.Add($"using {RootNamespaceTextBox.Text}.Entities;");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("using System.Threading.Tasks;");
            classLines.Add("using System.Data.SqlClient;");
            classLines.Add("");
            classLines.Add($"namespace {RootNamespaceTextBox.Text}.Repositories");
            classLines.Add("{");
            classLines.Add($"    public class {tableName}Repository : {SecondryNamespaceTextBox.Text}.GenericRepository<{getSingularNoun(tableName)}>, RepositoryAbstracts.I{tableName}Repository");
            classLines.Add("    {");
            classLines.Add($"        public {tableName}Repository(string connectionString) : base(connectionString)");
            classLines.Add("        {");
            classLines.Add("        }");
            classLines.Add("");
            foreach (var column in columnModels)
            {
                classLines.Add($"        public async Task<List<{getSingularNoun(tableName)}>> GetBy{column.Name}Async ({Tools.ConvertSqlToClr(column.DataType, column.IsNullable)} value)");
                classLines.Add("        {");
                var dataType = Tools.ConvertSqlToClr(column.DataType, column.IsNullable);
                if (dataType == "string")
                {
                    classLines.Add($"            return await RunQuaryAsync(\"SELECT * FROM [{schema}].[{tableName}] WHERE [{column.Name}] LIKE @Value\", new SqlParameter(\"Value\", value));");
                }
                else
                {
                    classLines.Add($"            return await RunQuaryAsync(\"SELECT * FROM [{schema}].[{tableName}] WHERE [{column.Name}] = @Value\", new SqlParameter(\"Value\", value));");

                }
                classLines.Add("        }");

            }
            classLines.Add("    }");
            classLines.Add("}");

            File.WriteAllLines(Path.Combine(path, tableName + "Repository.cs"), classLines);
        }

        private string getSingularNoun(string name)
        {
            if (name.EndsWith("ies"))
                return name.Substring(0, name.Length - 3) + "y";
            else if (name.EndsWith("es") && (name[name.Length - 3] == 's' || name[name.Length - 3] == 'x') || 
                (name[name.Length - 3] == 'h' && name[name.Length - 4] == 'c'))
                return name.Substring(0, name.Length - 2);
            else if (name.EndsWith("s"))
                return name.Substring(0, name.Length - 1);
            else
                return name;
        }

        private void SetItemsEnabled(bool state)
        {
            DatabasesComboBox.Enabled = SelectAllCheckBox.Enabled =
                            DataSourceTextBox.Enabled = UserIDCheckBox.Enabled = UsernameIDTextBox.Enabled
                            = TablesCheckedListBox.Enabled = PasswordTextBox.Enabled = GenerateButton.Enabled 
                            = DBConnectionButton.Enabled = SaveModelButton.Enabled = OpenModelButton.Enabled = state;
        }

        private void UserIDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UsernameIDTextBox.Enabled = PasswordTextBox.Enabled = UserIDCheckBox.Checked;
        }

        private void SaveModelButton_Click(object sender, EventArgs e)
        {
            var filePath = Path.Combine(Application.StartupPath, "Model.dat");
            var model = new ValuesModel()
            {
                RootNamespace = RootNamespaceTextBox.Text,
                SecondryNamespace = SecondryNamespaceTextBox.Text,
                Table = TableTextBox.Text,
                PrimaryKey = PrimaryKeyTextBox.Text,
                Computed = ComputedColumnTextBox.Text,
                Identity = IdentityColumnTextBox.Text,
                MaxLength = MaxLengthTextBox.Text,
                AllowNull = AllowNullTextBox.Text,
                RepositoryInterface = RepositoryInterfaceTextBox.Text,
                Unique = UniqueAttributeTextBox.Text,
            };
            Tools.SerializeObject(filePath, model);
            MessageBox.Show("Model saved successfuly.", "Serialize", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenModelButton_Click(object sender, EventArgs e)
        {
            var model = Tools.DeserializeObject(Path.Combine(Application.StartupPath, "Model.dat"));
            if (model == null)
                return;

            RootNamespaceTextBox.Text = model.RootNamespace;
            SecondryNamespaceTextBox.Text = model.SecondryNamespace;
            TableTextBox.Text = model.Table;
            PrimaryKeyTextBox.Text = model.PrimaryKey;
            ComputedColumnTextBox.Text = model.Computed;
            IdentityColumnTextBox.Text = model.Identity;
            MaxLengthTextBox.Text = model.MaxLength;
            AllowNullTextBox.Text = model.AllowNull;
            RepositoryInterfaceTextBox.Text = model.RepositoryInterface;
            UniqueAttributeTextBox.Text = model.Unique;

        }
    }
}
