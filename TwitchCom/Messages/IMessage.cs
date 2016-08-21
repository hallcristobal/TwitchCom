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
        string Value { get;}
        string User { get; }
        Type Type { get; }
        string Raw { get; }

        void ParseTags(string raw);
    }
}
