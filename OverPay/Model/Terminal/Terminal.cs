using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Terminal
{
    public class Terminal
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? PrivilegeId { get; set; }
        public int? PrivilegeFlags { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public int? CreateUserId { get; set; }
        
        public int? UpdateUserId { get; set; }
        public int MerchantId { get; set; }
        
        public string SerialNumber { get; set; }
        public int TypeId { get; set; }
        
        public int StatusId { get; set; }
       
        public int ModelId { get; set; }
       
        public string ApplicationVersion { get; set; }
        public string OSVersion { get; set; }
        public int? RegistererId { get; set; }
        
        public int? VerifierId { get; set; }
      
        public string UUID { get; set; }
        public bool IsActive { get; set; }
        public string CustomerSlipHeader { get; set; }
        public string MerchantSlipHeader { get; set; }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}
