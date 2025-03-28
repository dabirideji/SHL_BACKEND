using System;
using System.Collections.Generic;
using System.Linq;

namespace CSL.Models.DTO
{
    public class PagingList<T> : List<T>
    {
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public List<T> data { get; set; }

        public PagingList(List<T> items, int count)
        {
            recordsFiltered = count;
            recordsTotal = count;
            data = items;
            AddRange(items);
        }

        //public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = source.Count();
        //    pageSize = (pageSize == 0 ? (count > 0 ? count : 0) : pageSize);
        //    var items = source
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize).ToList();

        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}


        public static PagingList<T> ToPagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagingList<T>(items, count);
        }
    }



    public class PagedList<T> : List<T>
    {
        public PagedResponse PagedResponse { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PagedResponse = new PagedResponse
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            pageSize = (pageSize == 0 ? (count > 0 ? count : 0) : pageSize);
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }


        //public static PagedList<T> ToPagedList(IQueryable<T> source, int pageIndex = 1, int pageSize = 10)
        //{
        //    var count = source.Count();
        //    var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //    return new PagedList<T>(items, count, pageIndex, pageSize);
        //}
    }
}
