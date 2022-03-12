using System;
using System.Collections.Generic;
using System.Text;


namespace P01.Stream_Progress.Streams
{
    public abstract class StreamProgressor
    {
        private IStreamable file;

        // If we want to stream a music file, we can't
        public StreamProgressor(IStreamable file)
        {
            this.file = file;
        }

        public virtual int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
