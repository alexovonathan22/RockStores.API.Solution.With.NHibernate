//using Iesi.Collections.Generic;

using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public class Orders

    {
        public Orders()
        {
        }

        /// <summary>
        /// The customer who placed the order.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// The payment method of the order.
        /// </summary>
        public virtual string PaymentMethod { get; set; } = "cash";

        /// <summary>
        /// The order number of the order.
        /// </summary>
        /// <value>This value is assigned by the system.</value>
        public virtual int ID { get; set; }
    }
}
