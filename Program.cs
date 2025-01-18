// See https://aka.ms/new-console-template for more information
using System;
using NBitcoin;

namespace _125350929
{
  class Program
  {
    static void Main(string[] args)
    {
      Key privateKey = new Key();
      PubKey publicKey = privateKey.PubKey;
      Console.WriteLine(publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main));
      Console.WriteLine(publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.TestNet));

      var publicKeyHash = new KeyId("14836dbe7f38c5ac3d49e8d790af808a4ee9edcf");

      var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);
      var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
    
      Console.WriteLine(mainNetAddress.ScriptPubKey); // OP_DUP OP_HASH160 14836dbe7f38c5ac3d49e8d790af808a4ee9edcf OP_EQUALVERIFY OP_CHECKSIG
      Console.WriteLine(testNetAddress.ScriptPubKey);

      var paymentScript = publicKeyHash.ScriptPubKey;

      var sameMainNetAddress = paymentScript.GetDestinationAddress(Network.Main);

      Console.WriteLine(mainNetAddress == sameMainNetAddress); // True

      var samePublicKeyHash = (KeyId) paymentScript.GetDestination();

      var sameMainNetAddress2 = new BitcoinPubKeyAddress(samePublicKeyHash, Network.Main);

      Console.WriteLine(mainNetAddress == sameMainNetAddress2); // True
    }
  }
}
