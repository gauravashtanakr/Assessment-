﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DtParameters
    {
        public int Draw { get; set; }
        public DtColumn[] Columns { get; set; }
        public DtOrder[] Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DtSearch Search { get; set; }
        public string SortOrder => Columns != null && Order != null && Order.Length > 0 ? (Columns[Order[0].Column].Data + (Order[0].Dir == DtOrderDir.Desc ? " " + Order[0].Dir : string.Empty)) : null;
        public IEnumerable<string> AdditionalValues { get; set; }

    }
    public class DtColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DtSearch Search { get; set; }
    }
    public class DtOrder
    {
        public int Column { get; set; }
        public DtOrderDir Dir { get; set; }
    }

    public enum DtOrderDir
    {
        Asc,
        Desc
    }

    public class DtSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class DtResult<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
