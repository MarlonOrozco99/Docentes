using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using System;
using Xamarin.Forms;
using DocentesAPP.Droid;

[assembly: Dependency(typeof(Api))]
namespace DocentesAPP.Droid
{
    public class Api : IRestApi
    {
        public bool LoginApp()
        {
            try
            {
                RestClient _Client = new RestClient("https://todoapimao.azurewebsites.net/api/login/echoping"); //URL
                RestRequest _request = new RestRequest("", Method.POST)
                { RequestFormat = DataFormat.Json};

                _request.AddParameter("usuario", "Utap");
                _request.AddParameter("password", "123456");

                // _request.AddBody();

                var respuesta = _Client.Execute(_request);
                Console.WriteLine("The server return: " + respuesta.Content);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}