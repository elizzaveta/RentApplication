// using RentApplication.DAL.Models;
//
// namespace RentApplication.PL.Builders
// {
//     public class BuilderDirector
//     {
//         private IBuilder _builder;
//         
//         public IBuilder Builder
//         {
//             set => _builder = value;
//         }
//         
//         // Директор может строить несколько вариаций продукта, используя
//         // одинаковые шаги построения.
//         public void BuildClient(Client client)
//         {
//             
//         }
//         public void BuildRequest(Request request)
//         {
//                 _builder.WithId(request.Id)
//                 .WithClient(request.Client)
//                 .WithProperty(request.Property)
//                 .WithRealtor(request.Realtor)
//                 .WithTenant(request.Tenant)
//                 .WithIsActive(request.IsActive)
//                 .Build();
//         }
//         public void BuildProperty()
//         {
//             this._builder.BuildPartA();
//         }
//         public void BuildRealtor()
//         {
//             this._builder.BuildPartA();
//         }
//         public void BuildTenant()
//         {
//             this._builder.BuildPartA();
//         }
//     }
// }

