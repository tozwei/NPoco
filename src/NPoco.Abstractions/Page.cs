using System.Collections.Generic;

namespace NPoco
{
    public class Page<T> 
    {
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public long ItemsPerPage { get; set; }
        public List<T> Items { get; set; }

        /// <summary>
        /// 消息状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Data { get; set; }

    }
}