using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceMtk_P1_20180140067;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeMtk_P2_20180140067
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();

            try
            {
                //ALAMAT BASE ADDRESS
                hostObj = new ServiceHost(typeof(Matematika), address);

                //ALAMAT ENDPOINT
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, "");
                
                //wsdl
                ServiceMetadataBehavior smb = new
                ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //Untuk mengaktifkan wsdl(dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);

                //mex
                Binding mexbind =
                MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
