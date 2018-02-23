using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum BLOCKSTATES
{
    NOBLOCK,
    BLOCKHIGH,
    BLOCKLEFT,
    BLOCKRIGHT
}

public enum enemystates
{
    idle,
    cooldown,
    telegraphleft,
    attackleft,
    telegraphright,
    attackright,
    telegraphhigh,
    attackhigh,
    telegraphblock,
    block
}
