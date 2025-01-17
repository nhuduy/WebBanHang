//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanHang.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.order_details = new HashSet<order_details>();
        }
    
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<System.DateTime> shipped_date { get; set; }
        public string ship_name { get; set; }
        public string ship_address1 { get; set; }
        public string ship_address2 { get; set; }
        public string ship_city { get; set; }
        public string ship_state { get; set; }
        public string ship_postal_code { get; set; }
        public string ship_country { get; set; }
        public Nullable<decimal> shipping_fee { get; set; }
        public string payment_type { get; set; }
        public Nullable<System.DateTime> paid_date { get; set; }
        public string order_status { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual employee employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }
    }
}
