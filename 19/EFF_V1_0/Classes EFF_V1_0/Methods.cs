using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Esta classe está relaciona a classe de eventos (Events class), todo evento criado, deverá ter um método linkado aqui.
namespace EFF_V1_0.Classes_EFF_V1_0
{
    //Como criar um Método:
    //**AQUI, POR QUESTÕES DE NECESSIDADE, É POSSÍVEL CRIAR SUB-CLASSES DENTRO DA CLASSE METHODS**
    //Crie uma função interna, estática, que retorne o valor do tipo de evento desejado (EventHandler, KeyPressHandler, etc), com um nome, de livre escolha, seus parãmetros, serão todos ou alguns dos parâmetros solicitados pela função da classe Events, podendo adicionar mais parâmetros caso desejado (Porém este processo não é muito aconselhavel, pois torna o código na classe de eventos "poluido")    

    //Dentro da função interna, primeiro, crie o código para retornar o valor do evento utilizado, lembrando que o método deve respeitar a solicitação do evento utilizado (possuir o tipo de retorno correto e os parâmetros necessários para o evento, somente)
    //Crie a função, dentro da função interna, que se adeque as especificações do evento desejado, e dentro faça o código que o evento, quando ocorrido, irá direcionar.
    //Exemplo 2.0
    //internal static EventHandler FO_Form_Main_GetInformations_Button_Click(fO_Form_Main form, ExternalCommandData externalCommandData, ref string refer, ElementSet element)//processo para aplciar a marca d'água nas famílias
    //{
    //    return new EventHandler(FO_Form_Main_GetInformations_Button_Click_Method);
    //    void FO_Form_Main_GetInformations_Button_Click_Method(object sender, EventArgs e)
    //    { }
    //}
    //Exemplo 2.1
    //internal static EventHandler FO_Form_Main_GetInformations_Button_Click(ExternalCommandData externalCommandData, ref string refer, ElementSet element)//processo para aplciar a marca d'água nas famílias
    //{
    //    return new EventHandler(Method_Click);
    //    void Method_Click(object sender, EventArgs e)
    //    { }
    //}
    //Exemplo 2.2
    //internal static EventHandler FO_Form_Main_GetInformations_Button_Click(ExternalCommandData externalCommandData, ref string refer, ElementSet element)//processo para aplciar a marca d'água nas famílias
    //{
    //    return new KeyPressEventHandler(Method_Click);
    //    void Method_KeyPress(object sender, KeyPressEventArgs e)
    //    { }
    //}
    //.
    //.
    //.
    static class Methods
    {
        static internal List<string> GetAllFiles (string directoryPath, Func<string, bool> predicate)
        {   
            List<string> subDirectories = Directory.GetDirectories(directoryPath).ToList();
            List<string> files = Directory.GetFiles(directoryPath).Where(predicate).ToList();

            while(subDirectories.Count>0)
            {
                subDirectories.AddRange(Directory.GetDirectories(subDirectories[0]).ToList());
                files.AddRange(Directory.GetFiles(subDirectories[0]).Where(predicate).ToList());
                subDirectories.Remove(subDirectories[0]);
            }

            return files;
        }
    }
}
