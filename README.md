# TerraShop E-commerce

First of all why named it TerraShop? - Terra Luna coin recently crashed to ashes and this is just an attempt to honor those who lost life savings on this crash. Note - This is not a production app or anywhere close it.

## Motivation

I was asked to write a simple application following best practices as a part of my interivew process. Best practice is very opinionated term when we dig deeper. Different influencers in this field has different view on it. Some want it to be super minimalistic and just hard code everything until it's not required otherwise. Some says best practice is to write it clean from day one even if it's going to live sometime. I normally take middle ground, however middle ground is sometimes risky you will get flanks for both ends for not being close to either. These interivew tech challenges takes time and if you are like me you have to do it after hours or weekend -i.e. you are stealing time away from your family and kids to give a shot at something where an stranger who may if you are lucky understands your thought process.

If I have it my way, My inclination is to go super minimalistc piece that works and slowly refactor it to an engineering marvel. However I equally value re-usable frameworky or library kind of code that builds up making writing business logic pieces easier. So this repo has both of them.

## Assumptions & Decisions

### Monolith vs Microservices

This is an excellent reference application showing one of the ways to do same thing in this problem domain (https://github.com/dotnet-architecture/eShopOnContainers) using microservices approach. While there are clear service boundaries on the reference implementation, the actual service boundary identification is a long continuous exercise on its own. A single developer defining such boundary alone without involving other stakeholders based on the only the use cases defined in the problem space (which was very minimal) is wrong approach.

So this application going to be a monolith but some hints of separations at data storage end. However, care has been taken to minimise coupling and easy separation in future if we want to go microservices approach.

### Basket Per Visitor

Server doesn't manage session and a unique visitor identification is resposiblity of client/frontend. For backend, it's a unique guid only.
