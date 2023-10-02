using API.ASSISTENCIA_TECNICA_OS.DTO;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Service.Utils;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Peca
{
    public class PecasRadarService : IPecasRadarService
    {
        private readonly ReaderFile _readerFile;

        public PecasRadarService(ReaderFile readerFile)
        {
            _readerFile = readerFile;
        }

        public async Task<List<PecasRadarDto>> GetAll()
        {
            var list = new List<PecasRadarDto>();
            using var leitor = _readerFile.GetFileReader();
            await leitor.ReadLineAsync();

            while (!leitor.EndOfStream)
            {
                string linha = leitor.ReadLine();
                string[] valor = linha.Split("|");

                list.Add(new PecasRadarDto
                {
                    ClasseCodigo = CustomReplace(valor[0]),
                    Familia = CustomReplace(valor[1]),
                    Codigo = CustomReplace(valor[2]),
                    Descricao = CustomReplace(valor[3]),
                    Unidade = CustomReplace(valor[4]),
                });
            }

            return list;
        }
        private static string CustomReplace(string value)
        {
            return value.Replace("\"", "");
        }
    }
}
