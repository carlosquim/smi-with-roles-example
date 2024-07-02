// the includeInteractiveCredentials constructor parameter can be used to enable interactive authentication
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


// message to be shown in the page
var stringData="";
// Init default credential
var credential = new Azure.Identity.DefaultAzureCredential();
//Address for web destination you'll call (no auth for now)
var baseAddress = "https://testtokencqm002.azurewebsites.net/";
var api = "api/Todo";
var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//init token
var token = new AccessToken();
//init http client
HttpClient client = new HttpClient(); 
//client.BaseAddress = new Uri(baseAddress);
client.DefaultRequestHeaders.Accept.Add(contentType);
//set initial time to measure delay using jwt autentication
DateTime T = System.DateTime.UtcNow; 

try
{
    // replace this with Application ID URI + /.default
    String appid = Environment.GetEnvironmentVariable("envAppRegistrationId");
    string apiAppRegistration= "api://"+appid+"/.default";
    token = credential.GetToken(new Azure.Core.TokenRequestContext(scopes:[apiAppRegistration],claims: "roles"));
    stringData=stringData + "roles:"+ "\r\nToken:" +token.Token.ToString()+"\r\n";
}
catch (System.Exception e)
{
    stringData=stringData+"Error getting token: "+e.Message;
}

//set token
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

try
{
    var response = await client.GetAsync(baseAddress + api);
    if (response.IsSuccessStatusCode)
        {
        stringData = stringData+ "Response from API:"+ await response.Content.ReadAsStringAsync();
        Console.WriteLine(stringData);
        }
        else{
        stringData=stringData+ "Error with code: "+response.StatusCode.ToString();
        }
string base64GuidAll = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

string base64GuidCall = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
}
catch (System.Exception e)
{
    
    stringData= stringData+"Error getting response, message: "+e.Message;
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => System.DateTime.UtcNow.ToString());

app.Run();
public record Record(
    string appservicename,
    string app,
    string id,
    string category,
    string name,
    double responseTime,
    DateTime date
);