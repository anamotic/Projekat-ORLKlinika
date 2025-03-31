using App.ServiceLayer.DTOs;

namespace App.ServiceLayer.Interfaces
{
    public interface ITerminService
    {
        int ZakaziTermin(ZakaziTerminDto dto);
    }
}
