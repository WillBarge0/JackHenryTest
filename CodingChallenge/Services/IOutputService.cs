// ***********************************************************************
// Assembly         : CodingChallenge
// Author           : Bill Barge
// Created          : 09-03-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 09-03-2023
// ***********************************************************************
// <copyright file="IOutputService.cs" company="CodingChallenge">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CodingChallenge.Services;

/// <summary>
/// Interface IOutputService
/// </summary>
public interface IOutputService
{
    /// <summary>
    /// Sends a value to the user.
    /// </summary>
    /// <param name="valueToBeSent">The value to be sent.</param>
    void SendOut(string valueToBeSent);
}