//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRACT_LAB_2_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employeers
    {
        public int employeer_id { get; set; }
        public string employeer_name { get; set; }
        public string employeer_surname { get; set; }
        public string employeer_middlename { get; set; }
        public int id_post { get; set; }
    
        public virtual Posts Posts { get; set; }
    }
}