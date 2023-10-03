using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.Utils;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Peca
{
    public class PecasRadarService : IPecasRadarService
    {
        private readonly ReaderFile _readerFile;
        private Context _context;

        public PecasRadarService(ReaderFile readerFile, Context context)
        {
            _readerFile = readerFile;
            _context = context;
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
        public async Task<List<PecasModel>> InsertPecas()
        {
            var list = await GetAll();
            var listModel = new List<PecasModel>();
            foreach(var item in list)
            {
                listModel.Add(new PecasModel
                {
                    CodigoRadar = item.Codigo,
                    DataHoraCadastro = DateTime.UtcNow,
                    DataHoraAlteracao = DateTime.UtcNow,
                    Descricao = item.Descricao,
                    Preco = 0,
                    Familia = item.Familia,
                    Unidade= item.Unidade,
                    UsuarioAlteracaoId = new Guid("96afb069-c572-4302-b631-8b6b16c825e7"),
                    UsuarioCadastroId = new Guid("96afb069-c572-4302-b631-8b6b16c825e7")

                });
            }
            _context.Pecas.AddRange(listModel);
            await _context.SaveChangesAsync();
            return listModel;    
        }
        private static string CustomReplace(string value)
        {
            return value.Replace("\"", "");
        }
    }
}
