using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices
{
    public class GioHangAPIService : IGioHangAPIService
    {
        public async Task<int> Create(GioHang requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> CreateProductLike(GioHang requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/CreateProductLike", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Detele(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/Delete", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> DeleteProductLike(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/DeleteProductLike", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<GioHangPaging> GetByUser(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/GetByUser", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<GioHangPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<GioHangPaging> GetByUserProductLike(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/GetByUserProductLike", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<GioHangPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<GioHang> GetById(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/GioHang/GetById?Id=" + Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<GioHang>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<GioHang> GetByIdBill(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/GioHang/GetByIdBill?Id=" + Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<GioHang>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<GioHangPaging> GetListByUser(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/GetListByUser" , requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<GioHangPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<int> DeleteAll(GioHangRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/DeleteAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> Update(GioHang requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/Update", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> UpdateColor(GioHang requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/UpdateColor", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> UpdateQuantity(GioHang requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/GioHang/UpdateQuantity", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
