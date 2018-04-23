using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HideCommandButtons {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.DataBind();
        }

        private DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            for(int i = 0; i < 10; i++) {
                table.Rows.Add(i);
            }
            return table;
        }

        protected void ASPxGridView1_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs e) {
            bool isOddRow = e.VisibleIndex % 2 == 0;
            if(isOddRow) {  // some condition
                // hide the Edit button
                if(e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Edit)
                    e.Visible = false;

                // disable the selction checkbox
                if(e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.SelectCheckbox)
                    e.Enabled = false;
            }
        }
    }
}
