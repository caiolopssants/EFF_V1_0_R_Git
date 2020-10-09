using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI.Mechanical;
using Autodesk.Revit.UI.Plumbing;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Visual;




namespace EFF_V1_0.Classes_EFF_V1_0
{
    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData externalCommandData, ref string message, ElementSet elementSet)
        {
                       

            OpenFileDialog oFD = new OpenFileDialog() { Multiselect = false, Title = "Selecione o documento excel que contenha as informações dos parâmetros desejados", AddExtension = true, Filter = "CSV UTF-8 (Separado por virgula)|*.csv|Todos os arquivos|*" };//criando gerenciador de arquivos
            DialogResult dialogResultSharedParameters = oFD.ShowDialog();//obtendo arquivo excel
            string fileNameSharedParameters = string.Empty;//criando variável para armzenar o endereço do arquivo excel
            if (dialogResultSharedParameters == DialogResult.OK) { fileNameSharedParameters = oFD.FileName; } else { return Result.Cancelled; }//armazenado endereço do arquivo excel na variável criada


            FolderBrowserDialog fBD = new FolderBrowserDialog() { SelectedPath = Path.GetDirectoryName(oFD.FileName), Description = "Selecione o diretório que contenha os arquivos .rfa desejado" };//criando gerenciador de arquivos
            DialogResult dialogResultFamilyFilesDirectory = fBD.ShowDialog();//obtendo diretório contendo os arquivos do tipo família
            string directoryNameFamilyFiles = string.Empty;//criando variável para armzenar o endereço do diretório contendo os arquivos
            if (dialogResultFamilyFilesDirectory == DialogResult.OK) { directoryNameFamilyFiles = fBD.SelectedPath; } else { return Result.Cancelled; }//armazenado endereço do diretório na variável criada

            List<string> familyFiles = Methods.GetAllFiles(directoryNameFamilyFiles, x => Path.GetExtension(x).Contains("rfa"));//criando variável para armazenar todos os arquivos do tipo rfa, dentro do diretório informado (vasculhando em pastas e sub-pastas)

            List<General_Classes.Parameter> parametersToAddList = new List<General_Classes.Parameter>();//criando variável para armazenar as informações dentro do arquivo excel
            


            using (StreamReader sR = new StreamReader(fileNameSharedParameters,true))//abrindo documento excel
            {
                sR.ReadLine();//pulando o endereço 1, que é somente utilizado para identificar o titulo de cada coluna
                while(!sR.EndOfStream)
                {
                    string[] parameters = sR.ReadLine().Split(';');//dividi-se os elementos na linha pelo termo divisor ';'   

                    parametersToAddList.Add(new General_Classes.Parameter(parameters[0], Enum.GetValues(typeof(ParameterType)).Cast<ParameterType>().First(x => x.ToString() == parameters[1]), Enum.GetValues(typeof(BuiltInParameterGroup)).Cast<BuiltInParameterGroup>().First(x => x.ToString() == parameters[2]), parameters[3] == "Yes"));//criar vairável do tipo General_Classes.Parameter, onde será aramzenado cada valor separado no código anterior                    
                }
            }

            //Abrindo arquivos de família e adicionando os parâmetros

            List<UIDocument> uIDocuments = new List<UIDocument>();
            foreach (string file in familyFiles)
            {
                try
                {
                    uIDocuments.Add(externalCommandData.Application.OpenAndActivateDocument(file));
                    if (uIDocuments.Count > 1) { uIDocuments.First().SaveAs();  uIDocuments.First().SaveAndClose(); uIDocuments.Remove(uIDocuments.First()); }

                    foreach(General_Classes.Parameter parameter in parametersToAddList)
                    {
                        using (Transaction transic = new Transaction(uIDocuments.First().Document, "Adding family parameter"))
                        {
                            transic.Start();
                            try
                            {
                                uIDocuments.First().Document.FamilyManager.AddParameter(parameter.Name, parameter.BIPName, parameter.Type, parameter.Instance); //Adicionado um parâmetro qualquer                                
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show($"Error on parameter:\n {parameter}\n\nError message:\n {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                transic.Commit();
                            }
                        }
                    }
                }
                catch (Exception error)//remover essa exceção depois, pois ele pode se incomodo com uma grande quantidade de arquivos
                {
                    MessageBox.Show($"Error on family file:\n {file}\n\nError message:\n {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            File.WriteAllBytes($@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Void.rfa", Resources.Void);
            externalCommandData.Application.OpenAndActivateDocument($@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Void.rfa");
            uIDocuments.First().SaveAs(); uIDocuments.First().SaveAndClose(); uIDocuments.Remove(uIDocuments.First());            

            RevitCommandId closeDocPost = RevitCommandId.LookupPostableCommandId(PostableCommand.Close);
            externalCommandData.Application.PostCommand(closeDocPost);          
            return Result.Succeeded;            
        }
    }
}
