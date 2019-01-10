using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    public class User
    {
        private int UserID;
        private string Street;
        private string PostCode;
        private string Country;
        private List<Invite> InviteList;
        private double ReferalBalance;
        private string Email;
        private string UserType; //Staff / manager /user
        private List<FakeMessage> MessageList;
        private Card card;

        #region Getters
        public virtual int GetUserID()
        {
            return UserID;

        }
        public virtual string GetStreet()
        {
            return Street;
        }

        public virtual string GetPostCode()
        {
            return PostCode;
        }

        public virtual string GetCountry()
        {
            return Country;
        }

        public virtual double GetReferalBalance()
        {
            return ReferalBalance;
        }
        public virtual string GetUserType()
        {
            return UserType;
        }
        public virtual string GetEmail()
        {
            return Email;
        }

        public virtual List<Invite> GetInviteList()
        {
            return InviteList;
        }

        public virtual List<FakeMessage> GetMessageList()
        {
            return MessageList;
        }

        public virtual Card GetCard()
        {
            return card;
        }
        #endregion

        #region Setters
        public virtual void SetUserID(int value)
        {
            UserID = value;
        }

        public virtual void SetStreet(string value)
        {
            Street = value;
        }

        public virtual void SetPostCode(string value)
        {
            PostCode = value;
        }

        public virtual void SetCountry(string value)
        {
            Country = value;
        }

        public virtual void SetReferalBalance(double value)
        {
            ReferalBalance = value;
        }

        public virtual void SetEmail(string value)
        {
            Email = value;
        }
        public virtual void SetUserType(string value)
        {
            UserType = value;
        }
        public virtual void SetInviteList(List<Invite> value)
        {
            InviteList = value;
        }
        public virtual void SetMessageList(List<FakeMessage> value)
        {
            MessageList = value;
        }
        public virtual void SetCard(Card newCard)
        {
            card = newCard; 
        }
        #endregion
    }
}
