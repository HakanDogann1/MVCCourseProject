using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfMessageDal : GenericRepository<Message>, IMessageDal
	{
		Context context = new Context();
		public List<Message> GetByReadMessage()
		{
			return context.Messages.Where(x=>x.Read==true && x.ReceiverMail== "Admin@gmail.com").ToList();
		}

		public List<Message> GetByUnreadMessage()
		{
			return context.Messages.Where(x=>x.Read== false && x.ReceiverMail == "Admin@gmail.com").ToList();
		}
	}
}
