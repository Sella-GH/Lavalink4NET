using System;

namespace Lavalink4NET.Players;

using Lavalink4NET.Rest.Entities.Tracks;

public record class LavalinkPlayerOptions
{
    public bool DisconnectOnStop { get; set; }

    public bool DisconnectOnDestroy { get; set; } = true;

    public string? Label { get; set; }

    public ITrackQueueItem? InitialTrack { get; set; }

    public TimeSpan? InitialPosition { get; set; }

    public TrackLoadOptions InitialLoadOptions { get; set; }

    public float? InitialVolume { get; set; }

    public bool SelfDeaf { get; set; }

    public bool SelfMute { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether Lavalink4NET should automatically attempt to
    ///     recover voice connectivity when Discord closes the voice websocket with a recoverable
    ///     close code (4014 or 4015). When enabled, the player re-asserts the voice state on the
    ///     Discord gateway after a short delay, then waits for fresh credentials before retrying.
    /// </summary>
    public bool EnableVoiceAutoReconnect { get; set; } = true;

    /// <summary>
    ///     Gets or sets the delay applied before the first voice reconnect attempt. This gives the
    ///     Discord gateway enough time to finish reconnecting and re-identifying before we send a
    ///     fresh voice state update.
    /// </summary>
    public TimeSpan VoiceReconnectInitialDelay { get; set; } = TimeSpan.FromSeconds(2);

    /// <summary>
    ///     Gets or sets the maximum time to wait, per attempt, for Discord to respond to a voice
    ///     state update with a fresh <c>VOICE_SERVER_UPDATE</c>.
    /// </summary>
    public TimeSpan VoiceReconnectAttemptTimeout { get; set; } = TimeSpan.FromSeconds(8);

    /// <summary>
    ///     Gets or sets the maximum number of voice reconnect attempts before the recovery loop
    ///     gives up.
    /// </summary>
    public int VoiceReconnectMaxAttempts { get; set; } = 5;

    /// <summary>
    ///     Gets or sets the minimum time between successive voice reconnect runs. Subsequent
    ///     4014/4015 events within this window are ignored to prevent thrashing.
    /// </summary>
    public TimeSpan VoiceReconnectCooldown { get; set; } = TimeSpan.FromSeconds(15);

    /// <summary>
    ///     Gets or sets a value indicating whether the player should dispose itself when all voice
    ///     reconnect attempts fail. When <see langword="false"/> (the default), the player is kept
    ///     alive so the queue is preserved and the caller can decide how to proceed.
    /// </summary>
    public bool DisposeOnVoiceReconnectFailure { get; set; }
}