using AutoMapper;
using ConsoleApplication1.Dal;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pocos = ConsoleApplication1.Dal.Pocos;

namespace ConsoleApplication1.Bll
{

    public class TestBll
    {
        private TestUow _uow = null;

        public TestBll(string nameOrConnectionString)
        {
            _uow = new TestUow(nameOrConnectionString);
        }

        private Expression<Func<Pocos.Table1, bool>> MakeFileter(string keyword)
        {
            Expression<Func<Pocos.Table1, bool>> filter = null;
            if (!String.IsNullOrEmpty(keyword))
            {
                filter = w => w.Title.IndexOf(keyword) > -1;
                            
            }
            return filter;
        }
        public IEnumerable<Table1Model> Table1GetAll(int? pageNo = null, int? pageSize = null, string keyword = "")
        {
            Func<IQueryable<Pocos.Table1>, IOrderedQueryable<Pocos.Table1>> orderby =  o => o.OrderBy(s => s.Id);

            var pocoTable1 = _uow.Table1Repository.Get(pageNo, pageSize, orderBy: orderby, filter: MakeFileter(keyword)).ToList();
            if (pocoTable1.Any())
            {
                Mapper.CreateMap<Pocos.Table1, Table1Model>();
                var table1Model = Mapper.Map<List<Pocos.Table1>, List<Table1Model>>(pocoTable1);
                return table1Model;
            }
            return null;
        }

        public void Table1Add(Table1Model model)
        {
            Mapper.CreateMap<Table1Model, Pocos.Table1>();
            var poco = Mapper.Map<Table1Model, Pocos.Table1>(model);
            _uow.Table1Repository.Add(poco);
            _uow.Save();

        }

        public void Table1Update(Table1Model model)
        {
            //Mapper.CreateMap<Table1Model, Pocos.Table1>();
            //var poco = Mapper.Map<Table1Model, Pocos.Table1>(model);
            var poco = _uow.Table1Repository.GetSingle(s => s.Id == model.Id);

            _uow.Table1Repository.Update(poco);
            _uow.Save();

        }
    }
}
