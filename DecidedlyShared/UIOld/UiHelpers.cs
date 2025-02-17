﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DecidedlyShared.UIOld;

public static class UiHelpers
{
    public static int GetYPositionInScrollArea(int numberOfElements, int maxElementsVisible,
                                               int scrollAreaHeight, int scrollAreaTop,
                                               int currentTopIndex)
    {
        int barSteps = Math.Max(numberOfElements - maxElementsVisible, 1);
        int barStepSize = scrollAreaHeight / barSteps;

        return scrollAreaTop + currentTopIndex * barStepSize;
    }

    public static int GetTopIndexFromYPosition(int numberOfElements, int maxElementsVisible,
                                               int scrollAreaHeight, int scrollAreaTop, int mouseY)
    {
        mouseY -= scrollAreaTop - 32;
        int barSteps = Math.Max(numberOfElements - maxElementsVisible, 1);
        int barStepSize = scrollAreaHeight / barSteps;

        return mouseY / barStepSize;
    }
}
