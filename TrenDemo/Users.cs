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
    
    public partial class Users
    {
        public int U_Id { get; set; }
        public string U_Login { get; set; }
        public string U_Password { get; set; }
        public int U_Id_Role { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
