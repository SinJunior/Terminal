//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrenDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders_Tovar
    {
        public int OT_Id { get; set; }
        public int OT_Id_Tovar { get; set; }
        public int OT_Id_Order { get; set; }
        public Nullable<int> OT_Count { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Tovar Tovar { get; set; }
    }
}
