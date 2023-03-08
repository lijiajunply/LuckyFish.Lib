﻿namespace LuckyFish.Lib.FileSystem;

public interface IFileSystem
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Type { get; set; }
    public string Extension { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime WriteTime { get; set; }
    public long Size { get; set; }
    public void Rename(string newName);
    public void Delete();
    public void Move(string newDirectoryPath);
    public void Copy(string newDirectoryPath);
    public bool Exist();
}