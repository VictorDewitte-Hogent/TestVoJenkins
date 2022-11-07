using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using Domain.Packaging;
using System;
using System.Collections.Generic;
using Shared.Boxes;

namespace Services.Boxes
{
    public class BoxService : IBoxService
    {
        private static readonly List<Box> boxes = new();
        static BoxService()
        {
            var boxFaker = new BoxFaker();
            boxes = boxFaker.Generate(50);
        }
         
        public async Task<BoxResponse.GetIndex> GetIndexAsync(BoxRequest.GetIndex request)
        {
            await Task.Delay(100);
            BoxResponse.GetIndex response = new();
            var query = boxes.AsQueryable();

            
            query = query.Where(x => x.CustomerId == request.CustomerId);

            response.TotalAmount = query.Count();

            query = query.Skip(request.Amount * request.Page);
            query =  query.Take(request.Amount);

            query.OrderBy(x => x.Name);
            response.Boxes = query.Select(x => new BoxDto.Index
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Name = x.Name,
                Width = (int) x.Width,
                Height = (int) x.Height,
                Length = (int) x.Length,
            }).ToList();

            return response;
        }

        public async Task<BoxResponse.GetDetail> GetDetailAsync(BoxRequest.GetDetail request)
        {
            await Task.Delay(100);
            BoxResponse.GetDetail response = new();
            response.Box = boxes.Select(x => new BoxDto.Detail
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Name = x.Name,
                Width = (int) x.Width,
                Height = (int) x.Height,
                Length = (int) x.Length,
            }).SingleOrDefault(x => x.Id == request.BoxId);

            return response;
        }

        public async Task DeleteAsync(BoxRequest.Delete request)
        {
            await Task.Delay(100);
            var b = boxes.SingleOrDefault(x => x.Id == request.BoxId);
            boxes.Remove(b);
        }

        public async Task<BoxResponse.Create> CreateAsync(BoxRequest.Create request)
        {
            await Task.Delay(100);
            BoxResponse.Create response = new();

            var model = request.Box;
            var box = new Box(model.CustomerId ,model.Name, model.Width, model.Height, model.Length)
            {
                Id = boxes.Max(x => x.Id) + 1
            };

            boxes.Add(box);
            response.BoxId = box.Id;

            return response;
        }

        public async Task<BoxResponse.Edit> EditAsync(BoxRequest.Edit request)
        {
            await Task.Delay(100);
            BoxResponse.Edit response = new();
            var box = boxes.SingleOrDefault(x => x.Id == request.BoxId);

            var model = request.Box;

            box.Name = model.Name;
            box.Width = model.Width;
            box.Height = model.Height;
            box.Length = model.Length;

            response.BoxId = box.Id;
            return response;
        }
    }

}

