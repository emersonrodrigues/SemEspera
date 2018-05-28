using Newtonsoft.Json.Converters;
using System;
using System.IO;
using Newtonsoft.Json;

namespace SemEspera.Helpers
{
    public class JsonSerialize
    {
      
public static string Serialize<T>(T value) where T : class
    {

        Type type = value.GetType();
        Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

        //ignorando propriedades nulas
        json.NullValueHandling = NullValueHandling.Ignore;

        // ignorar referencias ciclicas em objetos
        json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        // formato da data, utilizar o iso
        json.DateFormatHandling = DateFormatHandling.IsoDateFormat;

        //if (type == typeof(DataTable))
        //    json.Converters.Add(new DataTableConverter());
        //else if (type == typeof(DataSet))
        //    json.Converters.Add(new DataSetConverter());

        StringWriter sw = new StringWriter();
        Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);

        writer.Formatting = Formatting.None;

        writer.QuoteChar = '"';
        json.Serialize(writer, value);

        string output = sw.ToString();
        writer.Close();
        sw.Close();

        return output;

    }
    public static T DeSerialize<T>(string value) where T : class
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        // se alguma propriedade nao existir no objeto, ignorar
        settings.MissingMemberHandling = MissingMemberHandling.Ignore;

        return JsonConvert.DeserializeObject<T>(value);

    }


}
}
