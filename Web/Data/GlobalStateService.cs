using Domain.ViewModels;

namespace Web.Data
{
  public class GlobalStateService: TokenViewModel
  {
    public GlobalStateService() { }

    public GlobalStateService Load(TokenViewModel viewModel)
    {
      Email = viewModel.Email;
      Name = viewModel.Name;
      Token = viewModel.Token;
      TokenExpires = viewModel.TokenExpires;

      return this;
    }
    public GlobalStateService Clear()
    {
      Email = String.Empty;
      Name = String.Empty;
      Token = String.Empty;
      TokenExpires = DateTime.MinValue;

      return this;
    }
  }
}
