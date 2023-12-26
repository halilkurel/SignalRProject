using Microsoft.AspNetCore.SignalR;
using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;

namespace SignalR.Api.Hubs
{
	public class SignalRHubs : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ImoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INatificationService _natificationService;

        public SignalRHubs(ICategoryService categoryService, IProductService productService, IOrderService orderService, ImoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INatificationService natificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _natificationService = natificationService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
		{
			var categoryCount = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.ActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.PasiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var hamburgerCount = _productService.TProductCountbyCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountbyCategoryNameHamburger", hamburgerCount);

            var drinkCount = _productService.TProductCountbyCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountbyCategoryNameDrink", drinkCount);

            var productAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductAvg", productAvg.ToString("0.00")+ "₺");

            var maxPriceProduct = _productService.TProductNamebyMaxPrice();
            await Clients.All.SendAsync("ReceiveMaxPriceProduct", maxPriceProduct);

            var minPriceProduct = _productService.TProductNamebyMinPrice();
            await Clients.All.SendAsync("ReceiveMinPriceProduct", minPriceProduct);

            var hamburgerPriceAvg = _productService.TProductPriceAvgHamburger();
            await Clients.All.SendAsync("ReceiveHamburgerPriceAvg", hamburgerPriceAvg.ToString("0.00") + "₺");

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPriceCount();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

            var totalmoneycaseamount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", totalmoneycaseamount.ToString("0.00") + "₺");

            var totaltodaymoneyamount = _orderService.TTotalTodayPrice();
            await Clients.All.SendAsync("ReceiveTotalOrderPrice", totaltodaymoneyamount.ToString("0.00") + "₺");

            var totalTable = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveTotalTable", totalTable);
        }


        public async Task SendProgress()
        {
            var totalPrice = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalPrice", totalPrice.ToString("0.00") + "₺");

            var activeOrder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrder", activeOrder);

            var activeTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", activeTableCount);

            var value5 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveMenuProductPriceAvg", value5);

            var value6 = _productService.TProductPriceAvgHamburger();
            await Clients.All.SendAsync("ReceiveProductPriceAvgHamburger", value6);

            var value7 = _productService.TProductCountbyCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountbyCategoryNameDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNatification()
        {
            var natification = _natificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNatificationFalse", natification);

            var natificationListByFalse = _natificationService.TGetAllNatificationByFalse();
            await Clients.All.SendAsync("ReceiveNatificationListByFalse",natificationListByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetAll();
            await Clients.All.SendAsync("ReceiveGetMenuTableStatus",value);
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }



    }
}
