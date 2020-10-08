using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Exceptions;
using System.IO;

namespace ControlledApplication
{
    public class ControlledApplication // é necessário que aplique-se esta classe, pois o programa buscará em seu código.
    {


        public void SetExternalInformations(ExternalCommandData externalCommandData, ref string reference, ElementSet elementSet, UIControlledApplication uIControlledApplication = null) //ele também chamará esta linha de código, sendo que sempre, ele irá enviar todas as informaçőes obre o código, tanto para comando quanto para o aplicativo
        {            
            try
            {
                UIControlledApplication = uIControlledApplication; // exemplo de aplicaçăo de variável, foi-se criado uma variável, de nome semelhante, porém a primeira letra é maiúscula, e receberá o valor da variável de nome parecido. Essa varável é direcionada para uma aplicaçăo que ocorrem na inicializaçăo do Revit, năo necessita do auxilio do usuario. Ele será enviado para o comando, pois caso voce tenha realizado uma alteraçao de código na sua aplicaçao, voce teria que fechar o revit e abri-lo novamente para rodar o app, porém destá forma, será somente necerrário lembrar de eliminar esse comando ao entrar no aplicativo e depois coloca-lo de volta, evitando assim que o comando de sobreponha.           
                //INFORME UM OU MAIS COMANDOS A SEREM EXECUTADOS PELO PROGRAMA EXTERNO AQUI
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }

        public static UIControlledApplication UIControlledApplication { get; set; } //parametro da classe ControlledApplication, destinado a outros métodos, caso necessitem desta informaçăo.
        public static bool ChmAddin { get; set; } // está variável é destinada a definir quando uma aplicativo está sendo controlado pelo chmAddin ou năo, essa variável evita que certos processos sejam executados em situaçőes que năo săo necessárias, principalmente quando se trata da classe app, pois como ele é acionado logo no incio do aplicativo, se por uma acaso, esse aplicativo incrementa um método para um evento em específico, caso vocę năo remova ele no final do aplicativo, toda vez que for iniciado o aplicativo, o método novo irá se sobrepor ao antigo. E caso vocę sempre tire o aplicativo, se vocę quiser rodar o mesmo aplicativo por fora, năo conseguira.

        //AVISO: no momento que se utiliza este aplicativo para um addin, se torna inválido acionar este aplicativo por fora, caso este addin possua um APP atribuido a seu código, pois pelo fato deste mesmo addin dentro do código do chmaddin, remover o método ao final do processo, caso você chame este mesmo addin por fora, pelo fato dele năo adicionar toda vez o método, sendo isto funçăo do app, ele năo irá funcionar e provavelmente irá bugar o Revit.


    }
}
