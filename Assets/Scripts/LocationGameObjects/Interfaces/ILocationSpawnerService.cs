﻿namespace LocationGameObjects.Interfaces
{
    public interface ILocationSpawnerService
    {
        public void SpawnLocationObjects(int location);
        public void DestroyLocationObject();
    }
}