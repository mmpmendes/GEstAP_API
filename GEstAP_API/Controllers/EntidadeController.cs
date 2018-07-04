using EstruturaAP_DB;
using GEstAP_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GEstAP_API.Controllers
{
    public class EntidadeController : ApiController
    {
        // GET api/entidade/getall
        public IEnumerable<EntidadeBO> GetAll()
        {
            IList<EntidadeBO> toReturn = new List<EntidadeBO>();
            using (EstruturaAPEntities entities = new EstruturaAPEntities())
            {
                foreach (Estrutura estrutura in entities.Estrutura)
                {
                    EntidadeBO elementToReturn = createEntidadeBO(entities, estrutura);
                    toReturn.Add(elementToReturn);
                }
            }
            return toReturn;
        }

        private static EntidadeBO createEntidadeBO(EstruturaAPEntities entities, Estrutura estrutura)
        {
            EntidadeBO elementToReturn = new EntidadeBO();

            elementToReturn.CodEstrutura = estrutura.CodEstrutura;
            Entidade entidade = entities.Entidade.Where(ent => ent.CodEntidade == estrutura.CodEntidade && ent.Ativo).FirstOrDefault();
            if (estrutura != null)
            {
                elementToReturn.CodEstrutura = estrutura.CodEstrutura;
                elementToReturn.CodEstruturaInterno = estrutura.CodEstruturaInterno;
            }
            else
            {
                elementToReturn.CodEstrutura = null;
            }

            if (entidade != null)
            {
                elementToReturn.Designacao = entidade.Designacao;
                elementToReturn.Sigla = entidade.Sigla;
            }
            elementToReturn.Supervisor = (from est in entities.Estrutura
                                          where est.CodEntidade == estrutura.CodEntidade
                                          select est.CodEstruturaInterno).FirstOrDefault();

            return elementToReturn;
        }

        [HttpGet]
        // GET api/entidade/getbycodigo?codigo=AC1000200000010100
        public EntidadeBO GetByCodigo(string codigo)
        {

            using (EstruturaAPEntities entities = new EstruturaAPEntities())
            {
                EntidadeBO toReturn = null;
                Estrutura estrutura = entities.Estrutura.Where(est => est.CodEstrutura == codigo).FirstOrDefault();
                if (estrutura != null)
                {
                    Entidade entidade = entities.Entidade.Where(ent => ent.CodEntidade == estrutura.CodEntidade).FirstOrDefault();
                    toReturn = new EntidadeBO()
                    {
                        CodEntidade = entidade.CodEntidade,
                        CodEstrutura = estrutura.CodEstrutura,
                        CodEstruturaInterno = estrutura.CodEstruturaInterno,
                        Designacao = entidade.Designacao,
                        Sigla = entidade.Sigla,
                        Supervisor = estrutura.Supervisor.CodEstruturaInterno
                    };
                }
                return toReturn;
            }
        }

        [HttpGet]
        // GET api/entidade/getdependentsbycodigo?codigo=AC1000200000010100
        public List<EntidadeBO> GetDependentsByCodigo(string codigo)
        {
            using (EstruturaAPEntities entities = new EstruturaAPEntities())
            {
                List<EntidadeBO> toReturn = null;
                Estrutura estrutura = entities.Estrutura.Where(est => est.CodEstrutura == codigo).FirstOrDefault();
                if (estrutura != null)
                {
                    List<Estrutura> dependentes = entities.Estrutura.Where(est => est.Depende == estrutura.CodEstruturaInterno).ToList();
                    toReturn = new List<EntidadeBO>();
                    foreach (Estrutura item in dependentes)
                    {
                        Entidade entidade = entities.Entidade.Where(ent => ent.CodEntidade == item.CodEntidade).FirstOrDefault();
                        EntidadeBO newEntidade = new EntidadeBO()
                        {
                            CodEntidade = item.CodEntidade,
                            CodEstrutura = item.CodEstrutura,
                            CodEstruturaInterno = item.CodEstruturaInterno,
                            Designacao = entidade.Designacao,
                            Sigla = entidade.Sigla,
                            Supervisor = estrutura.Supervisor.CodEstruturaInterno
                        };

                        toReturn.Add(newEntidade);
                    }
                }
                return toReturn;
            }
        }

        //[HttpGet]
        //public List
    }
}