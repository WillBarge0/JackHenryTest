// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-02-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="OutputService.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CodingChallenge.Services;

/// <summary>
/// A Service to send strings to the user
/// </summary>
public class OutputService : IOutputService
{
    /// <summary>
    /// Sends a value to the user.
    /// </summary>
    /// <param name="valueToBeSent">The value to be sent.</param>
    public void SendOut(string valueToBeSent)
    {
        Console.WriteLine(valueToBeSent);
    }
}