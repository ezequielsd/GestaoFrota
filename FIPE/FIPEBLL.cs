using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPE
{
    public class FIPEBLL
    {
        public List<TipoFIPEinfo> FindTiposFIPE()
        {
            return new List<TipoFIPEinfo>
            {
                new TipoFIPEinfo{Tipo = "carros", Descricao = "Carros"},
                new TipoFIPEinfo{Tipo = "caminhoes", Descricao = "Caminhão e Micro-Onibus"},
                new TipoFIPEinfo{Tipo = "motos", Descricao = "Motos"}
            };
        }

        public List<MarcaFIPEinfo> FindMarcasFIPE(string tipo)
        {
            var client = new RestClient(new Uri("http://fipeapi.appspot.com/"));

            var req = new RestRequest("api/1/{tipo}/marcas.json", Method.Get);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<MarcaFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public List<CarroFIPEinfo> FindCarrosFIPE(string tipo, int idMarca)
        {
            var client = new RestClient(new Uri("http://fipeapi.appspot.com/")); ;

            var req = new RestRequest("api/1/{tipo}/veiculos/{id}.json", Method.Get);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<CarroFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public List<CarroAnoFIPEinfo> FindCarrosAnoFIPE(string tipo, int idMarca, long idCarro)
        {
            var client = new RestClient(new Uri("http://fipeapi.appspot.com/"));

            var req = new RestRequest("api/1/{tipo}/veiculo/{id}/{idC}.json", Method.Get);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);
            req.AddParameter("idC", idCarro, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<CarroAnoFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public ConsultaFIPEinfo FindPrecoFIPE(string tipo, int idMarca, long idCarro, string idAno)
        {
            var client = new RestClient(new Uri("http://fipeapi.appspot.com/"));

            var req = new RestRequest("api/1/{tipo}/veiculo/{id}/{idC}/{idA}.json", Method.Get);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);
            req.AddParameter("idC", idCarro, ParameterType.UrlSegment);
            req.AddParameter("idA", idAno, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<ConsultaFIPEinfo>(response.Content);

            return contentResponse;
        }
    }
}
