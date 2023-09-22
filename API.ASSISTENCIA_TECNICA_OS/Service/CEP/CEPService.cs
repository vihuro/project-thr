using API.ASSISTENCIA_TECNICA_OS.DTO.CEP;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using System.Text.Json;

namespace API.ASSISTENCIA_TECNICA_OS.Service.CEP
{
    public class CEPService : ICEPService
    {
        private readonly IMapper _mapper;

        public CEPService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ReturnCEPDto> Get(int cep)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            using var client = new HttpClient();

            var responseBrasilApi = await client.SendAsync(request);
            if (responseBrasilApi.IsSuccessStatusCode)
            {
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<CepDto>(contentResp);


                var obj = _mapper.Map<ReturnCEPDto>(objResponse);
                return obj;

            }
            throw new CustomException("CEP não encontrado!") { HResult = 404 };

        }
    }
}
