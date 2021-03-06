//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LMSEntities : DbContext
    {
        public LMSEntities()
            : base("name=LMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<new_User> new_User { get; set; }
        public virtual DbSet<Order_Book> Order_Book { get; set; }
        public virtual DbSet<Return_Book> Return_Book { get; set; }
    
        public virtual int p_order(Nullable<int> user_id, string book_Name, Nullable<System.DateTime> issue_Date)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            var book_NameParameter = book_Name != null ?
                new ObjectParameter("Book_Name", book_Name) :
                new ObjectParameter("Book_Name", typeof(string));
    
            var issue_DateParameter = issue_Date.HasValue ?
                new ObjectParameter("Issue_Date", issue_Date) :
                new ObjectParameter("Issue_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_order", user_idParameter, book_NameParameter, issue_DateParameter);
        }
    
        public virtual int p_updatereturn(Nullable<int> order_Id, string book_Name, Nullable<System.DateTime> issue_Date)
        {
            var order_IdParameter = order_Id.HasValue ?
                new ObjectParameter("Order_Id", order_Id) :
                new ObjectParameter("Order_Id", typeof(int));
    
            var book_NameParameter = book_Name != null ?
                new ObjectParameter("Book_Name", book_Name) :
                new ObjectParameter("Book_Name", typeof(string));
    
            var issue_DateParameter = issue_Date.HasValue ?
                new ObjectParameter("Issue_Date", issue_Date) :
                new ObjectParameter("Issue_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_updatereturn", order_IdParameter, book_NameParameter, issue_DateParameter);
        }
    
        public virtual ObjectResult<returnview_Result> returnview(Nullable<int> user_Id)
        {
            var user_IdParameter = user_Id.HasValue ?
                new ObjectParameter("user_Id", user_Id) :
                new ObjectParameter("user_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<returnview_Result>("returnview", user_IdParameter);
        }
    }
}
