using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WebMotorsProject.API;
using Newtonsoft.Json;
using FluentAssertions;
using WebMotorsProject.Domain.Data.DTO;


namespace WebMotorsProject.Test
{
    public class TestAPI
    {
        private HttpClient _client;
             
        
        [Test]
        public void Test1Post()
        {
            ClientConfiguration();
            #region Marca
            var responseMarca = _client.GetAsync("/api/marca").Result;

            responseMarca.EnsureSuccessStatusCode();

            responseMarca.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseMarca = responseMarca.Content.ReadAsStringAsync().Result;
            var resultMarca = JsonConvert.DeserializeObject<List<MarcaDTO>>(apiResponseMarca);

            resultMarca.Should().NotBeNullOrEmpty();
            #endregion

            #region Modelo
                        
            var responseModelo = _client.GetAsync("/api/modelo?MakeID=" + resultMarca.First().Id).Result;

            responseModelo.EnsureSuccessStatusCode();

            responseModelo.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseModelo = responseModelo.Content.ReadAsStringAsync().Result;
            var resultModelo = JsonConvert.DeserializeObject<List<ModeloDTO>>(apiResponseModelo);

            resultModelo.Should().NotBeNullOrEmpty();
            #endregion

            #region Versao                
            long modelIndex = resultModelo.First().Id;
            var responseVersao = _client.GetAsync("/api/versao?ModelID=" + modelIndex).Result;

            responseVersao.EnsureSuccessStatusCode();

            responseVersao.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseVersao = responseVersao.Content.ReadAsStringAsync().Result;
            var resultVersao = JsonConvert.DeserializeObject<List<VersaoDTO>>(apiResponseVersao);

            resultVersao.Should().NotBeNullOrEmpty();
            #endregion

            #region Veiculo 
            
            var responseVeiculo = _client.GetAsync("/api/veiculo?Page=" + modelIndex).Result;

            responseVeiculo.EnsureSuccessStatusCode();

            responseVeiculo.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseVeiculo = responseVeiculo.Content.ReadAsStringAsync().Result;
            var resultVeiculo = JsonConvert.DeserializeObject<List<VeiculoDTO>>(apiResponseVeiculo);
            resultVeiculo.Should().NotBeNullOrEmpty();

            List<VeiculoDTO> veiculos = new List<VeiculoDTO>();
            foreach (var versao in resultVersao)
            {
                veiculos = resultVeiculo.Where(r => r.Versao == versao.Nome).ToList();

                if (veiculos != null && veiculos.Count > 0) break;
            }

            if (veiculos.Count == 0)
                veiculos.AddRange(resultVeiculo);

            #endregion

            #region Post
            
            var veiculo = veiculos.First();


            AnuncioDTO ad = new AnuncioDTO()
            {
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Versao = veiculo.Versao,
                KM = veiculo.KM,
                Ano = veiculo.AnoModelo,
                Observacao = "Inserindo novo Anúncio"
            };


            HttpContent content = new StringContent(JsonConvert.SerializeObject(ad), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/anuncio", content).Result;

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponsePost = response.Content.ReadAsStringAsync().Result;
            var resultPut = JsonConvert.DeserializeObject<AnuncioDTO>(apiResponsePost);

            resultPut.Should().Equals(ad);

            #endregion

            _client?.Dispose();


        }

        [Test]
        public void Test2Put()
        {
            ClientConfiguration();

            var responseAll = _client.GetAsync("/api/anuncio").Result;

            responseAll.EnsureSuccessStatusCode();

            responseAll.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseAll = responseAll.Content.ReadAsStringAsync().Result;
            var resultAll = JsonConvert.DeserializeObject<List<AnuncioDTO>>(apiResponseAll);

            resultAll.Should().NotBeNullOrEmpty();

            AnuncioDTO ad = resultAll.Last();

            ad.Observacao = "Alterando Anuncio";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(ad), Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/anuncio", content).Result;

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponsePut = response.Content.ReadAsStringAsync().Result;
            var resultPut = JsonConvert.DeserializeObject<AnuncioDTO>(apiResponsePut);

            resultPut.Should().Equals(ad);

            _client?.Dispose();
        }

        [Test]
        public void Test3Get()
        {
            ClientConfiguration();
            var response = _client.GetAsync("/api/anuncio").Result;

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<AnuncioDTO>>(apiResponse);

            _client?.Dispose();

        }

        [Test]
        public void Test4GetById()
        {
            ClientConfiguration();

            var responseAll = _client.GetAsync("/api/anuncio").Result;

            responseAll.EnsureSuccessStatusCode();

            responseAll.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseAll = responseAll.Content.ReadAsStringAsync().Result;
            var resultAll = JsonConvert.DeserializeObject<List<AnuncioDTO>>(apiResponseAll);

            resultAll.Should().NotBeNullOrEmpty();

            var response = _client.GetAsync("/api/anuncio/" + resultAll.Last().Id).Result;

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AnuncioDTO>(apiResponse);

            result.Should().NotBeNull();

            _client?.Dispose();

        }

        [Test]
        public void Test5Delete()
        {
            ClientConfiguration();

            var responseAll = _client.GetAsync("/api/anuncio").Result;

            responseAll.EnsureSuccessStatusCode();

            responseAll.StatusCode.Should().Be(HttpStatusCode.OK);

            string apiResponseAll = responseAll.Content.ReadAsStringAsync().Result;
            var resultAll = JsonConvert.DeserializeObject<List<AnuncioDTO>>(apiResponseAll);

            resultAll.Should().NotBeNullOrEmpty();

            var response = _client.DeleteAsync("/api/anuncio/" + resultAll.Last().Id).Result;

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            _client?.Dispose();

        }

        public void ClientConfiguration()
        {
            var server = new TestServer(new WebHostBuilder()
                                    .ConfigureAppConfiguration((hostingContext, config) =>
                                    {
                                        var env = hostingContext.HostingEnvironment;

                                        config.AddJsonFile("appsettings.json", optional: true);                                        

                                        config.AddEnvironmentVariables();
                                    })
                                    .UseStartup<Startup>());
            _client = server.CreateClient();
        }

    }
}