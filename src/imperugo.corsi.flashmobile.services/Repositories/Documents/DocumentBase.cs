using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.corsi.flashmobile.services.Repositories.Documents
{
    public abstract class DocumentBase<T>
    {
	    protected DocumentBase()
	    {
		    this.CreateAt = DateTime.UtcNow;
	    }

		public T Id { get; set; }
	    public DateTime CreateAt { get; set; }
    }
}
