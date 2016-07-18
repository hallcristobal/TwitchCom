namespace TwitchCom.Messages
{
    public enum Type
    {
        PRIVMSG,
        JOIN,
        PART,
        MODE,
        NOTICE,
        HOSTTARGET,
        CLEARCHAT,
        USERSTATE,
        RECONNECT,
        EXCEPTION,
        USERNOTICE,
        PONG,
        ROOMSTATE,
        NONE
    };

    public interface IMessage
    {
        string Value { get; set; }
        string User { get; set; }
        Type Type { get; set; }
        string Raw { get; set; }

        void ParseMessage(string raw);
    }
}
