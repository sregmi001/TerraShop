# TerraShop E-commerce

First of all why named it TerraShop? - Terra Luna coin recently crashed to ashes and this is just an attempt to honor those who lost life savings on this crash. Note - This is not a production app or anywhere close it.

## Motivation

I was asked to write a simple application following best practices as a part of my interivew process. Best practice is very opinionated term when we dig deeper. Different influencers in this field has different view on it. End of the day it's doing the right thing best of business priorities long term and short term, making sure your colleagues don't spend days pulling their hair trying to understand your code. I hope my attempt to not over invest time on this but also try to utilise bits that make extension easier hasn't turned into an ugly monster. These interivew tech challenges takes time and if you are like me you have to do it after hours or weekend -i.e. you are stealing time away from your family esp kids to give a shot at something where an stranger who may if you are lucky understands your thought process.

## Assumptions & Decisions

### Monolith vs Microservices

This is an excellent reference application showing one of the ways to do same thing in this problem domain (https://github.com/dotnet-architecture/eShopOnContainers) using microservices approach. While there are clear service boundaries on the reference implementation, the actual service boundary identification is a long continuous exercise on its own. A single developer defining such boundary alone without involving other stakeholders based on the only the use cases defined in the problem space (which was very minimal) is wrong approach.

So this application going to be a monolith but some hints of separations at data storage end. However, care has been taken to minimise coupling and easy separation in future if we want to go microservices approach.

### Basket Per Visitor

Server doesn't manage session and a unique visitor identification is resposiblity of client/frontend. For backend, it's a unique guid only.

## What hasn't been done at all

- No front end and no front end tests.
- Some of the basket functionality is missing.
