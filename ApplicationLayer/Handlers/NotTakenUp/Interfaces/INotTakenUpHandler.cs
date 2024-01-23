namespace ApplicationLayer.Handlers.NotTakenUp.Interfaces
{
    using ApplicationLayer.Handlers.NotTakenUp.Models;
    using FunderApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotTakenUpHandler
    {
      Task<NotTakenUpActivityResponse> Run(NotTakenUpActivityRequest request);
    }
}
