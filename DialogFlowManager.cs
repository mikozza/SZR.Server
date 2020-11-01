using Google.Cloud.Dialogflow.V2;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;

namespace SZR
{
    public static class DialogFlowManager
    {


        public static WebhookResponse GetDialogFlowResponse(string userId, string message)
        {
            WebhookResponse webHookResp = message.StartsWith("Sorry") ? InitializeResponse(false, userId) : InitializeResponse(true, userId);

            var fulfillmentMessage = webHookResp.FulfillmentMessages[0];

            fulfillmentMessage.SimpleResponses = new Intent.Types.Message.Types.SimpleResponses();
            var simpleResp = new Intent.Types.Message.Types.SimpleResponse();
            simpleResp.Ssml = $"<speak>{message}</speak>";
            fulfillmentMessage.SimpleResponses.SimpleResponses_.Add(simpleResp);

            return webHookResp;
        }

        private static WebhookResponse InitializeResponse(bool expectUserInput, string userId)
        {
            WebhookResponse webResp = new WebhookResponse();

            var message = new Intent.Types.Message();
            webResp.FulfillmentMessages.Add(message);
            message.Platform = Intent.Types.Message.Types.Platform.ActionsOnGoogle;

            Value payloadVal = new Value();
            payloadVal.StructValue = new Struct();

            Value expectedUserResp = new Value();
            expectedUserResp.BoolValue = expectUserInput;
            payloadVal.StructValue.Fields.Add("expectUserResponse", expectedUserResp);

            Value userStorageValue = new Value();

            UserStorage userStorage = new UserStorage();
            userStorage.UserId = userId;
            userStorageValue.StringValue = JsonConvert.SerializeObject(userStorage);

            payloadVal.StructValue.Fields.Add("userStorage", userStorageValue);

            Struct payloadStruct = new Struct();

            payloadStruct.Fields.Add("google", payloadVal);

            webResp.Payload = payloadStruct;

            return webResp;
        }

        private static string GetUserId(WebhookRequest request)
        {

            string userId = null;
            Struct intentRequestPayload = request.OriginalDetectIntentRequest?.Payload;



            return userId;
        }

        [JsonObject]
        public class UserStorage
        {

            [JsonProperty(PropertyName = "userId")]
            public string UserId { get; set; }
        }

    }
}
