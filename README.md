# AI Zero-Knowledge Proofs Concept

This repository presents a proof of concept for implementing AI zero-knowledge proofs. It explores how AI can facilitate the verification of claims or properties without exposing sensitive data or intellectual property.
I believe this concept is important to get right if we aim for a trustless future — that is, a future where trust is inherent by design, thanks to trustless computing.

## How It Works

The proposed system would operate largely as follows:

1. A secure "black box" environment is established, leveraging cryptographic methods for security.
2. **Alice** uploads sensitive data into the black box, tied to clearly defined data contracts.
3. AI agents within the black box operate strictly within the bounds set by these data contracts.
4. **Bob** queries the AI agents with questions that can only be answered within the contract's boundaries defined by **Alice**, ensuring no sensitive information is disclosed.

## Use Cases

AI zero-knowledge proofs can be applied in various domains, including but not limited to:

1. **Personalized Software**: Ensuring sensitive data cannot be leaked while offering personalized experiences.
2. **Medical Research**: Allowing researchers to verify hypotheses based on medical data without direct access to personal health information.
3. **Software Integrity**: Ensuring the software on your device operates benevolently.
4. **Trust Verification**: Verifying that individuals in positions of trust are not compromised (e.g., not being bribed).
5. **Consent Compliance**: Ensuring software operations align with personalized user consents.
6. **Product Authenticity**: Verifying the authenticity and ethical sourcing of products.
7. **Financial Compliance**: Proving that financial institutions adhere to regulations and do not facilitate money laundering.

## How To Use This POC
1. You currently need an IDE that runs C#
2. Within Program.cs you will see CasinoAppExample being inituated when the program is run, while BitcoinExample and PositionOfTrustExample is uncommented.
2.a They all work under the same principle; to verify one malicious and one benevolent example.
3. You will be prompted to enter your OpenAI api key when running the ConsoleClient

## Limitations

There are many, this is not a working product in any way, but I will list some major ones:

1. **Trusted Execution Environment (TEE)**: The software requires execution within a TEE to ensure its integrity.
   - *Homomorphic Encryption*: Might be necessary for processing data securely.
2. **Data Integrity**: Verifying that the uploaded data is complete and unaltered is critical.
   - *Human in the Loop*: Any potential for human-readable output poses a security risk.
   - *Content Authenticity*: Mechanisms like C2PA may be needed to safeguard against input tampering.
3. **AI Reliability**: AI can still be tricked and currently they are in no way at a point where AI ZKP's are possible. I do believe they will get to a point where humans or equally intelligent AIs will have a hard time tricking it, and it just takes one failed attempt of a malicious actor to break the trust
