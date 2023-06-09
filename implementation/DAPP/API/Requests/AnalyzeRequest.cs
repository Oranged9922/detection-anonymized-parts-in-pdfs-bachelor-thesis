﻿namespace API.Requests;
/// <summary>
/// A request for a file location
/// </summary>
/// <param name="FileLocation"> The location of the file</param>
public record AnalyzeRequest(string FileLocation, bool ReturnImages = false);