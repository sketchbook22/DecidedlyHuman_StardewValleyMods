﻿using System;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;

namespace DecidedlyShared.Input;

public record struct MouseWatch(MouseButton button, KeyPressType Type, Action? Callback, Action<string, LogLevel>? LogCallback);
