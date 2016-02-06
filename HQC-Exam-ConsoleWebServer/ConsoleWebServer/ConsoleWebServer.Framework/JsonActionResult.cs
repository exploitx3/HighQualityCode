﻿using System;
using System.Collections.Generic;using System.Text;
using System.Net;

using Newtonsoft.Json;

public class JsonActionResult : IActionResult {
    public virtual HttpStatusCode GetStatusCode() {
        return HttpStatusCode.OK;
    }
    public JsonActionResult(HttpRq rq, object m)
    {
        model = m;
        Request = rq;
        ResponseHeaders = new List<KeyValuePair<string, string>>();
    }
    public HttpRq Request { get; private set; }
    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
    public string GetContent() {
        return JsonConvert.SerializeObject(model);
    }
    public readonly object model;
    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(Request.ProtocolVersion, GetStatusCode(), GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
        foreach (var responseHeader in ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }
        return response;
    }
}
public class JsonActionResultWithCors : JsonActionResult{
    public JsonActionResultWithCors(HttpRq request, object model, string corsSettings)
        : base(request, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
public class JsonActionResultWithoutCaching : JsonActionResult{
    public JsonActionResultWithoutCaching(HttpRq r, object model)
        : base(r, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        throw new Exception();
    }
}
public class JsonActionResultWithCorsWithoutCaching : JsonActionResult{
    public JsonActionResultWithCorsWithoutCaching(HttpRq request, object model, string corsSettings)
        : base(request, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}