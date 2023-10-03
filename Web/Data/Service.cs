using Domain.Entities;
using Newtonsoft.Json;

namespace Web.Data
{
  public class Service<T> where T: Base, new()
  {
    private readonly string domain = "https://localhost:44342/{0}/{1}";

    public Service()
    {
      domain = string.Format(domain, new T().GetType().Name.ToLower(), "{0}");
    }

    private string GetUrl(string method) => string.Format(domain, method);

    public async Task<List<T>> GetAll()
    {
      try
      {
        var url = GetUrl("get-all");
        using var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ResultViewModel<List<T>>>(responseBody);

        if (result != null)
          return result.Data;

        return new List<T>(); 
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new List<T>();
      }
    }

    public async Task<T> GetById(int id)
    {
      try
      {
        var url = GetUrl($"get/{id}");
        using (var client = new HttpClient())
        {
          HttpResponseMessage response = await client.GetAsync(url);
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();

          var result = JsonConvert.DeserializeObject<ResultViewModel<T>>(responseBody);

          if (result != null)
            return result.Data;

          return new();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new T();
      }
    }

    public async Task<T> Post(T entity)
    {
      try
      {
        var url = GetUrl("post");
        using (var client = new HttpClient())
        {
          HttpResponseMessage response = await client.PostAsJsonAsync(url, entity);
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();

          var result = JsonConvert.DeserializeObject<ResultViewModel<T>>(responseBody);

          if (result != null)
            return result.Data;

          return new();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new T();
      }
    }

    public async Task<T> Put(T entity)
    {
      try
      {
        var url = GetUrl("put");
        using (var client = new HttpClient())
        {
          HttpResponseMessage response = await client.PutAsJsonAsync(url, entity);
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();

          var result = JsonConvert.DeserializeObject<ResultViewModel<T>>(responseBody);

          if (result != null)
            return result.Data;

          return new();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new T();
      }
    }

    public async Task<T> Delete(int id)
    {
      try
      {
        var url = GetUrl($"delete/{id}");
        using (var client = new HttpClient())
        {
          HttpResponseMessage response = await client.DeleteAsync(url);
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();

          var result = JsonConvert.DeserializeObject<ResultViewModel<T>>(responseBody);

          if (result != null)
            return result.Data;

          return new();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new T();
      }
    }

    public async Task<TResponse> GetBy<TResponse>(string endpoint) where TResponse : new()
    {
      var url = GetUrl(endpoint);
      using var client = new HttpClient();
      HttpResponseMessage response = await client.GetAsync(url);
      response.EnsureSuccessStatusCode();
      string responseBody = await response.Content.ReadAsStringAsync();

      var result = JsonConvert.DeserializeObject<ResultViewModel<TResponse>>(responseBody);

      if (result != null)
        return result.Data;

      return new();
    }
  }

  public class ResultViewModel<T> where T: new()
  {
    public string Message { get; set; } = String.Empty;
    public bool Success { get; set; }
    public T Data { get; set; } = new();
  }
}
