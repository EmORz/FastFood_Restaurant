using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Employees;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;

namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(p =>p.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForPath(x => x.Position.Name, y => y.MapFrom(d => d.PositionName));

            this.CreateMap<Employee, EmployeesAllViewModel>()
               .ForMember(x => x.Position, y => y.MapFrom(p => p.Position.Name));

            //Categorıes
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(k => k.CategoryName));

            //Item
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(z => z.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(u => u.Category.Name)); 

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(z => z.DateTime.ToString("g")));

        }
    }
}
